using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES_steps
{
    class AES
    {
        delegate int positionArray(int round, int column, int row);
        delegate int positionArray4(int column, int row);

        private static int _countRound = 11;

        private static byte[] _rcon = { 0x00, 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36 };

        private static byte[] _sbox = {
            0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76,
            0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0,
            0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc, 0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15,
            0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a, 0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75,
            0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0, 0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84,
            0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b, 0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf,
            0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85, 0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8,
            0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5, 0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2,
            0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17, 0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73,
            0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88, 0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb,
            0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c, 0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79,
            0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9, 0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08,
            0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6, 0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a,
            0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e, 0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e,
            0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94, 0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf,
            0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68, 0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16
        };

        private static byte[] _invSbox = {
            0x52, 0x09, 0x6a, 0xd5, 0x30, 0x36, 0xa5, 0x38, 0xbf, 0x40, 0xa3, 0x9e, 0x81, 0xf3, 0xd7, 0xfb,
            0x7c, 0xe3, 0x39, 0x82, 0x9b, 0x2f, 0xff, 0x87, 0x34, 0x8e, 0x43, 0x44, 0xc4, 0xde, 0xe9, 0xcb,
            0x54, 0x7b, 0x94, 0x32, 0xa6, 0xc2, 0x23, 0x3d, 0xee, 0x4c, 0x95, 0x0b, 0x42, 0xfa, 0xc3, 0x4e,
            0x08, 0x2e, 0xa1, 0x66, 0x28, 0xd9, 0x24, 0xb2, 0x76, 0x5b, 0xa2, 0x49, 0x6d, 0x8b, 0xd1, 0x25,
            0x72, 0xf8, 0xf6, 0x64, 0x86, 0x68, 0x98, 0x16, 0xd4, 0xa4, 0x5c, 0xcc, 0x5d, 0x65, 0xb6, 0x92,
            0x6c, 0x70, 0x48, 0x50, 0xfd, 0xed, 0xb9, 0xda, 0x5e, 0x15, 0x46, 0x57, 0xa7, 0x8d, 0x9d, 0x84,
            0x90, 0xd8, 0xab, 0x00, 0x8c, 0xbc, 0xd3, 0x0a, 0xf7, 0xe4, 0x58, 0x05, 0xb8, 0xb3, 0x45, 0x06,
            0xd0, 0x2c, 0x1e, 0x8f, 0xca, 0x3f, 0x0f, 0x02, 0xc1, 0xaf, 0xbd, 0x03, 0x01, 0x13, 0x8a, 0x6b,
            0x3a, 0x91, 0x11, 0x41, 0x4f, 0x67, 0xdc, 0xea, 0x97, 0xf2, 0xcf, 0xce, 0xf0, 0xb4, 0xe6, 0x73,
            0x96, 0xac, 0x74, 0x22, 0xe7, 0xad, 0x35, 0x85, 0xe2, 0xf9, 0x37, 0xe8, 0x1c, 0x75, 0xdf, 0x6e,
            0x47, 0xf1, 0x1a, 0x71, 0x1d, 0x29, 0xc5, 0x89, 0x6f, 0xb7, 0x62, 0x0e, 0xaa, 0x18, 0xbe, 0x1b,
            0xfc, 0x56, 0x3e, 0x4b, 0xc6, 0xd2, 0x79, 0x20, 0x9a, 0xdb, 0xc0, 0xfe, 0x78, 0xcd, 0x5a, 0xf4,
            0x1f, 0xdd, 0xa8, 0x33, 0x88, 0x07, 0xc7, 0x31, 0xb1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xec, 0x5f,
            0x60, 0x51, 0x7f, 0xa9, 0x19, 0xb5, 0x4a, 0x0d, 0x2d, 0xe5, 0x7a, 0x9f, 0x93, 0xc9, 0x9c, 0xef,
            0xa0, 0xe0, 0x3b, 0x4d, 0xae, 0x2a, 0xf5, 0xb0, 0xc8, 0xeb, 0xbb, 0x3c, 0x83, 0x53, 0x99, 0x61,
            0x17, 0x2b, 0x04, 0x7e, 0xba, 0x77, 0xd6, 0x26, 0xe1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0c, 0x7d
        };

        private byte[] _key;

        private static byte GMul(byte a, byte b)
        {
            /*
             Example: 
                (d4 x 02) + (bf x 03) + (5d x 01) + (30 x 01)
                d4 x 02 is d4 << 1, ^ 1b (because the high bit of d4 is set), giving b3;
                //======================================================================//
                how to multiply by 3, 9, 11, 13.....
                3 x X = (2 + 1) x X = (2 x X) + X 
                9 x X = (((X x 2) x 2) x 2) + X
                (where + is addition in GF(2^8) === xor)
                //======================================================================//
                bf x 03 is bf << 1, ^1b (because thi high bit of bf is set), and ^bf, giving da 
             */
            byte result = 0;
            byte hi_bit_set;

            for (var counter = 0; counter < 8; counter++)
            {
                if ((b & 0x01) != 0)
                    result ^= a;

                hi_bit_set = (byte)(a & 0x80);

                a <<= 1;

                if (hi_bit_set != 0)
                    a ^= 0x1b;

                b >>= 1;
            }

            return result;

        }

        public static byte SubBytes(byte input)
        {
            return _sbox[((input & 0xF0) >> 4) * 16 + (input & 0x0F)];
        }
        public static byte InvSubBytes(byte input)
        {
            return _invSbox[((input & 0xF0) >> 4) * 16 + (input & 0x0F)];
        }

        public static byte[] ShiftRows(byte[] input)
        {
            byte[] changeArray = new byte[4 * 4];
            for (var row = 0; row < 4; row++)
            {
                Array.Copy(input, 4 * row + row, changeArray, 4 * row, 4 - row);
            }
            for (var row = 1; row < 4; row++)
            {
                Array.Copy(input, 4 * row, changeArray, 4 * row + 4 - row, row);
            }

            return changeArray;
        }
        public static byte[] InvShiftRows(byte[] input)
        {
            byte[] changeArray = new byte[4 * 4];
            for (var row = 0; row < 4; row++)
            {
                Array.Copy(input, 4 * row, changeArray, 4 * row + row, 4 - row);
            }
            for (var row = 1; row < 4; row++)
            {
                Array.Copy(input, 4 * row + 4 - row, changeArray, 4 * row, row);
            }
            return changeArray;
        }


        public static byte[] MixColumns(byte[] input)
        {
            byte[] changeArray = new byte[4 * 4];

            positionArray4 index = (c, r) => (c + 4 * r);


            for (var column = 0; column < 4; column++)
            {
                changeArray[index(column, 0)] = (byte)(
                    GMul(input[index(column, 0)], 0x02) ^
                    GMul(input[index(column, 1)], 0x03) ^
                    input[index(column, 2)] ^
                    input[index(column, 3)]
                    );

                changeArray[index(column, 1)] = (byte)(
                    GMul(input[index(column, 1)], 0x02) ^
                    GMul(input[index(column, 2)], 0x03) ^
                    input[index(column, 0)] ^
                    input[index(column, 3)]
                    );

                changeArray[index(column, 2)] = (byte)(
                    GMul(input[index(column, 2)], 0x02) ^
                    GMul(input[index(column, 3)], 0x03) ^
                    input[index(column, 0)] ^
                    input[index(column, 1)]
                    );

                changeArray[index(column, 3)] = (byte)(
                    GMul(input[index(column, 0)], 0x03) ^
                    GMul(input[index(column, 3)], 0x02) ^
                    input[index(column, 1)] ^
                    input[index(column, 2)]
                    );

            }

            return changeArray;

        }

        public static byte[] InvMixColumns(byte[] input)
        {
            byte[] changeArray = new byte[4 * 4];

            positionArray4 index = (c, r) => (c + 4 * r);


            for (var column = 0; column < 4; column++)
            {
                changeArray[index(column, 0)] = (byte)(
                    GMul(input[index(column, 0)], 0x0E) ^
                    GMul(input[index(column, 1)], 0x0B) ^
                    GMul(input[index(column, 2)], 0x0D) ^
                    GMul(input[index(column, 3)], 0x09)
                    );

                changeArray[index(column, 1)] = (byte)(
                    GMul(input[index(column, 0)], 0x09) ^
                    GMul(input[index(column, 1)], 0x0E) ^
                    GMul(input[index(column, 2)], 0x0B) ^
                    GMul(input[index(column, 3)], 0x0D)
                    );

                changeArray[index(column, 2)] = (byte)(
                    GMul(input[index(column, 0)], 0x0D) ^
                    GMul(input[index(column, 1)], 0x09) ^
                    GMul(input[index(column, 2)], 0x0E) ^
                    GMul(input[index(column, 3)], 0x0B)
                    );

                changeArray[index(column, 3)] = (byte)(
                    GMul(input[index(column, 0)], 0x0B) ^
                    GMul(input[index(column, 1)], 0x0D) ^
                    GMul(input[index(column, 2)], 0x09) ^
                    GMul(input[index(column, 3)], 0x0E)
                    );


            }

            return changeArray;


        }



        public static byte[] AddRoundKey(byte[] input, byte[] key)
        {
            for (var i = 0; i < input.Length; i++)
            {
                input[i] ^= key[i];
            }
            return input;
        }

        public AES(byte[] key)
        {
            this._key = key;
        }

        public byte[] KeyExpansion()
        {
            byte[] roundKey = new byte[_countRound * 16];
            Array.Copy(_key, roundKey, 16);

            positionArray index = (rd, c, r) => (16 * rd + c + 4 * r);

            for (var round = 1; round < _countRound; round++)
            {
                // Copy W(i-1) in WI 
                for (var row = 1; row < 4; row++)
                {
                    roundKey[index(round, 0, row - 1)] = SubBytes(roundKey[index(round - 1, 3, row)]);
                }

                // Rotation word
                roundKey[index(round, 0, 3)] = SubBytes(roundKey[index(round - 1, 3, 0)]);

                for (var row = 0; row < 4; row++)
                {
                    roundKey[index(round, 0, row)] ^= roundKey[index(round - 1, 0, row)];
                }

                roundKey[index(round, 0, 0)] ^= _rcon[round];


                for (var column = 1; column < 4; column++)
                {
                    for (var row = 0; row < 4; row++)
                    {
                        roundKey[index(round, column, row)] = (byte)(roundKey[index(round - 1, column, row)] ^ roundKey[index(round, column - 1, row)]);
                    }

                }

            }

            return roundKey;
        }

        public byte[] Encrypt(byte[] input)
        {
            var key = KeyExpansion();

            if (input.Length % 16 != 0)
            {
                var temp = new byte[input.Length + (16 - input.Length % 16)];
                Array.Copy(input, temp, input.Length);
                input = temp;
            }

            var output = new List<byte>();

            var listKey = new List<byte[]>();

            for (var i = 0; i < key.Length; i += 16)
            {
                var arr = new byte[16];
                Array.Copy(key, i, arr, 0, 16);
                listKey.Add(arr);
            }

            for (var state = 0; state < input.Length; state += 16)
            {

                var arrState = new byte[16];
                Array.Copy(input, state, arrState, 0, 16);

                arrState = AddRoundKey(arrState, listKey[0]);

                for (var round = 1; round < _countRound - 1; round++)
                {
                    //Array.ForEach(arrState, element => element = SubBytes(element));
                    for (var i = 0; i < arrState.Length; i++)
                        arrState[i] = SubBytes(arrState[i]);

                    arrState = ShiftRows(arrState);
                    arrState = MixColumns(arrState);
                    arrState = AddRoundKey(arrState, listKey[round]);
                }

                //Array.ForEach(arrState, element => element = SubBytes(element));
                for (var i = 0; i < arrState.Length; i++)
                    arrState[i] = SubBytes(arrState[i]);

                arrState = ShiftRows(arrState);
                arrState = AddRoundKey(arrState, listKey[_countRound - 1]);


                Array.ForEach(arrState, element => output.Add(element));

            }

            return output.ToArray();
        }

        public byte[] Decrypt(byte[] input)
        {
            var key = KeyExpansion();
            var output = new List<byte>();

            var listKey = new List<byte[]>();


            for (var i = 0; i < key.Length; i += 16)
            {
                var arr = new byte[16];
                Array.Copy(key, i, arr, 0, 16);
                listKey.Add(arr);
            }

            for (var state = 0; state < input.Length; state += 16)
            {

                var arrState = new byte[16];
                Array.Copy(input, state, arrState, 0, 16);

                arrState = AddRoundKey(arrState, listKey[_countRound - 1]);

                for (var round = _countRound - 2; round > 0; round--)
                {
                    arrState = InvShiftRows(arrState);
                    //Array.ForEach(arrState, element => element = InvSubBytes(element));
                    for (var i = 0; i < arrState.Length; i++)
                        arrState[i] = InvSubBytes(arrState[i]);

                    arrState = AddRoundKey(arrState, listKey[round]);
                    arrState = InvMixColumns(arrState);
                }


                arrState = InvShiftRows(arrState);
                //Array.ForEach(arrState, element => element = InvSubBytes(element));
                for (var i = 0; i < arrState.Length; i++)
                    arrState[i] = InvSubBytes(arrState[i]);

                arrState = AddRoundKey(arrState, listKey[0]);


                Array.ForEach(arrState, element => output.Add(element));

            }

            return output.ToArray();
        }

    }

}
