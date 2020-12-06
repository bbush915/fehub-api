//-----------------------------------------------------------------------------
// <copyright file="GuidHelpers.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Security.Cryptography;
using System.Text;

namespace FEHub.Utilities.Helpers
{
    internal static class GuidHelpers
    {
        /// <summary>
        ///     The default namespace.
        /// </summary>
        public static readonly Guid DefaultNamespace = new Guid("28f31006-1200-4b19-b42d-19bdbaecb86a");

        /// <summary>
        ///     The namespace for fully-qualified domain names (from RFC 4122, Appendix C).
        /// </summary>
        public static readonly Guid DnsNamespace = new Guid("6ba7b810-9dad-11d1-80b4-00c04fd430c8");

        /// <summary>
        ///     The namespace for URLs (from RFC 4122, Appendix C).
        /// </summary>
        public static readonly Guid UrlNamespace = new Guid("6ba7b811-9dad-11d1-80b4-00c04fd430c8");

        /// <summary>
        ///     The namespace for ISO OIDs (from RFC 4122, Appendix C).
        /// </summary>
        public static readonly Guid IsoOidNamespace = new Guid("6ba7b812-9dad-11d1-80b4-00c04fd430c8");

        /// <summary>
        ///     Creates a name-based UUID using the algorithm from RFC 4122 §4.3 using the default namespace and the SHA-1 hash algorithm.
        /// </summary>
        /// <param name="namespace">
        ///     The namespace.
        /// </param>
        /// <param name="name">
        ///     The name.
        /// </param>
        /// <returns>
        ///     A UUID derived from the given name using the default namespace and the SHA-1 hash algorithm.
        /// </returns>
        /// <remarks>
        ///     See <a href="http://code.logos.com/blog/2011/04/generating_a_deterministic_guid.html">Generating a deterministic GUID</a>.
        /// </remarks>
        public static Guid Create(string name)
        {
            return Create(DefaultNamespace, name, 5);
        }

        /// <summary>
        ///     Creates a name-based UUID using the algorithm from RFC 4122 §4.3 using the SHA-1 hash algorithm.
        /// </summary>
        /// <param name="namespace">
        ///     The namespace.
        /// </param>
        /// <param name="name">
        ///     The name.
        /// </param>
        /// <returns>
        ///     A UUID derived from the given namespace and name using the SHA-1 hash algorithm.
        /// </returns>
        /// <remarks>
        ///     See <a href="http://code.logos.com/blog/2011/04/generating_a_deterministic_guid.html">Generating a deterministic GUID</a>.
        /// </remarks>
        public static Guid Create(Guid @namespace, string name)
        {
            return Create(@namespace, name, 5);
        }

        /// <summary>
        ///     Creates a name-based UUID using the algorithm from RFC 4122 §4.3.
        /// </summary>
        /// <param name="namespace">
        ///     The namespace.
        /// </param>
        /// <param name="name">
        ///     The name.
        /// </param>
        /// <param name="version">
        ///     The version number of the UUID to create:
        ///     3 for MD5, 5 for SHA-1
        /// </param>
        /// <returns>
        ///     A UUID derived from the given namespace and name.
        /// </returns>
        /// <remarks>
        ///     See <a href="http://code.logos.com/blog/2011/04/generating_a_deterministic_guid.html">Generating a deterministic GUID</a>.
        /// </remarks>
        public static Guid Create(Guid @namespace, string name, int version)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if ((version != 3) && (version != 5))
            {
                throw new ArgumentException($"The {nameof(version)} must be 3 or 5", nameof(version));
            }

            // NOTE(Bradley) - Convert the name to a sequence of octets (Step 3)

            // ASSUMPTION(Bradley) - UTF-8 encoding is always appropriate.
            var nameBytes = Encoding.UTF8.GetBytes(name);

            // NOTE(Bradley) - Convert the namespace UUID to network order (Step 3)

            var namespaceBytes = @namespace.ToByteArray();
            SwapByteOrder(namespaceBytes);

            // NOTE(Bradley) - Compute the hash of the namespace concatenated 
            // with the name (Step 4)

            byte[] hash;

            using (var hashAlgorithm = (version == 3) ? (HashAlgorithm)MD5.Create() : SHA1.Create())
            {
                hashAlgorithm.TransformBlock(namespaceBytes, 0, namespaceBytes.Length, null, 0);
                hashAlgorithm.TransformFinalBlock(nameBytes, 0, nameBytes.Length);

                hash = hashAlgorithm.Hash;
            }

            // NOTE(Bradley) - Most bytes from the hash are copied straight to 
            // the bytes of the new GUID (Steps 5-7, 9, 11-12)

            var uuidBytes = new byte[16];
            Array.Copy(hash, 0, uuidBytes, 0, 16);

            // NOTE(Bradley) - Set the four most significant bits (bits 12-15) 
            // of the time_hi_and_version field to the appropriate 4-bit 
            // version number from Section 4.1.3 (Step 8)

            uuidBytes[6] = (byte)((uuidBytes[6] & 0x0F) | (version << 4));

            // NOTE(Bradley) - Set the two most significant bits (bits 6-7) of
            // the clock_seq_hi_and_reserved to zero and one, respectively (Step 10)

            uuidBytes[8] = (byte)((uuidBytes[8] & 0x3F) | 0x80);

            // NOTE(Bradley) - Convert the resulting UUID to local byte order (Step 13)

            SwapByteOrder(uuidBytes);

            return new Guid(uuidBytes);
        }

        /// <summary>
        ///     Converts a GUID (expressed as a byte array) to and from network order (MSB-first).
        /// </summary>
        /// <param name="guidBytes">
        ///     The GUID (expressed as a byte array).
        /// </param>
        private static void SwapByteOrder(byte[] guidBytes)
        {
            SwapBytes(guidBytes, 0, 3);
            SwapBytes(guidBytes, 1, 2);
            SwapBytes(guidBytes, 4, 5);
            SwapBytes(guidBytes, 6, 7);
        }

        /// <summary>
        ///     Swaps the two specified bytes in a GUID (expressed as a byte array).
        /// </summary>
        /// <param name="guidBytes">
        ///     The GUID (expressed as a byte array).
        /// </param>
        /// <param name="left">
        ///     The left byte.
        /// </param>
        /// <param name="right">
        ///     The right byte.
        /// </param>
        private static void SwapBytes(byte[] guidBytes, int left, int right)
        {
            var temp = guidBytes[left];
            guidBytes[left] = guidBytes[right];
            guidBytes[right] = temp;
        }
    }
}