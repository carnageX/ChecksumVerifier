using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MD5HashCheckGUI
{
    class ChecksumVerifier
    {
        /// <summary>Generates checksum hash of a given file using a given algorithm.</summary>
        /// <param name="filename">File path and name to generate checksum.</param>
        /// <param name="hashOption">Checksum Algorithm.  Options are: MD5, SHA-1, SHA-256, SHA-384, and SHA-512</param>
        /// <returns>Hash string to be returned.</returns>
        public static string GetHash(string filename, string hashOption)
        {
            try
            {
                return ComputeHashAlgorithm(filename, hashOption);
            }//try
            catch
            {
                throw;
            }//catch
        }//GetHash

        /// <summary>Generates checksum hash of a given file using a list of given algorithms.</summary>
        /// <param name="filename">File path and name to generate checksum.</param>
        /// <param name="hashOption">List of Checksum Algorithms.  Options are: MD5, SHA-1, SHA-256, SHA-384, and SHA-512</param>
        /// <returns>List of hash strings to be returned.</returns>
        public static List<string> GetHash(string filename, List<string> hashOption)
        {
            List<string> returnHashes = new List<string>();
            try
            {
                foreach (var s in hashOption)
                {
                    returnHashes.Add(ComputeHashAlgorithm(filename, s));
                }//foreach
            }//try
            catch
            {
                throw;
            }//catch
            return returnHashes;
        }//GetHash

        /// <summary>Gets the computed checksum for the provided file using the provided algorithm</summary>
        /// <param name="filename">File to read</param>
        /// <param name="hashOption">Hash algorithm to use when generating checksum</param>
        /// <returns></returns>
        private static string ComputeHashAlgorithm(string filename, string hashOption)
        {
            string computedHash = String.Empty;

            if (hashOption.ToLower() == "md5")
            {
                MD5 md5Checksum = MD5.Create();
                using (FileStream fs = File.Open(filename, FileMode.Open))
                {
                    computedHash = FormatHashChecksum(md5Checksum.ComputeHash(fs));
                }//using  
            }//if
            else if (hashOption.ToLower() == "sha-1")
            {
                SHA1 sha1Checksum = SHA1.Create();
                using (FileStream fs = File.Open(filename, FileMode.Open))
                {
                    computedHash = FormatHashChecksum(sha1Checksum.ComputeHash(fs));
                }//using 
            }//else if
            else if (hashOption.ToLower() == "sha-256")
            {
                SHA256 sha256Checksum = SHA256.Create();
                using (FileStream fs = File.Open(filename, FileMode.Open))
                {
                    computedHash = FormatHashChecksum(sha256Checksum.ComputeHash(fs));
                }//using 
            }//else if
            else if (hashOption.ToLower() == "sha-384")
            {
                SHA384 sha384Checksum = SHA384.Create();
                using (FileStream fs = File.Open(filename, FileMode.Open))
                {
                    computedHash = FormatHashChecksum(sha384Checksum.ComputeHash(fs));
                }//using 
            }//else if
            else if (hashOption.ToLower() == "sha-512")
            {
                SHA512 sha512Checksum = SHA512.Create();
                using (FileStream fs = File.Open(filename, FileMode.Open))
                {
                    computedHash = FormatHashChecksum(sha512Checksum.ComputeHash(fs));
                }//using 
            }//else if
            else if (hashOption.ToLower() == "ripemd160")
            {
                RIPEMD160 ripemd160Checksum = RIPEMD160.Create();
                using (FileStream fs = File.Open(filename, FileMode.Open))
                {
                    computedHash = FormatHashChecksum(ripemd160Checksum.ComputeHash(fs));
                }//using
            }//else if
            else if (hashOption.ToLower() == "crc16")
            {
                CRC16 crc16Checksum = new CRC16();
                using (FileStream fs = File.Open(filename, FileMode.Open))
                {
                    foreach (byte b in crc16Checksum.ComputeHash(fs))
                    {
                        computedHash = computedHash.Insert(0, b.ToString("x2").ToLower());
                    }//foreach
                }//using
                //throws arithmetic overflow when choosing crc16
            }//else if
            else if (hashOption.ToLower() == "crc32")
            {
                CRC32 crc32Checksum = new CRC32();
                using (FileStream fs = File.Open(filename, FileMode.Open))
                {
                    foreach (byte b in crc32Checksum.ComputeHash(fs))
                    {
                        computedHash = computedHash.Insert(0, b.ToString("x2").ToLower());
                    }//foreach
                }//using
            }//else if
            else
            {
                computedHash = "Not a valid algorithm option!";
            }//else
            return computedHash;
        }//ComputeHashAlgorithm

        /// <summary>Formats the inputted byte array by removing hyphens</summary>
        /// <param name="hashArray">Byte array computed from checksum</param>
        /// <returns>Formatted checksum string</returns>
        private static string FormatHashChecksum(byte[] hashArray)
        {
            return BitConverter.ToString(hashArray).Replace("-", "").ToLower();
        }//FormatHashChecksum

        /// <summary>Compares two checksums and returns true if they are the same, otherwise false.</summary>
        /// <param name="hash1">First checksum hash to compare</param>
        /// <param name="hash2">Second checksum hash to compare</param>
        /// <returns>True/False if hash strings are the same</returns>
        public static bool CompareHashes(string hash1, string hash2)
        {
            if (String.Equals(hash1.ToLower().Trim(), hash2.ToLower().Trim()))
                return true;
            else
                return false;
        }//CompareHashes

        /// <summary>Compares a list of checksum strings to a single inputted checksum.</summary>
        /// <param name="hash">Single checksum to compare against.</param>
        /// <param name="hashFileList">List of checksum strings to compare against the single checksum.</param>
        /// <returns></returns>
        public static bool CompareHashes(string hash, List<string> hashFileList)
        {
            return hashFileList.Contains(hash.Trim());
        }//CompareHashes
    }//ChecksumVerifier
}//namespace
