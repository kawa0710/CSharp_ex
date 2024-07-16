// https://stackoverflow.com/questions/75880865/c-sharp-net-6-asymmetric-encryption-best-way-to-export-and-import-public-and
// Author: Topaco
// https://dotnetfiddle.net/AGUIAW

using System;
using System.Security.Cryptography;
using System.Text;

public class Program {
  public static void Main() {
    using(var rsaOriginal = RSA.Create()) // Create original keys
    using(var rsaImportedPriv = RSA.Create()) // For the later import of the private key
    using(var rsaImportedPub = RSA.Create()) // For the later import of the public key
    {
      // Generate keys in PemEncoding
      var pkcs8Pem = rsaOriginal.ExportPkcs8PrivateKeyPem();
      var spkiPem = rsaOriginal.ExportSubjectPublicKeyInfoPem();
      Console.WriteLine(pkcs8Pem);
      Console.WriteLine(spkiPem);

      // Import as PEM
      rsaImportedPriv.ImportFromPem(pkcs8Pem);
      rsaImportedPub.ImportFromPem(spkiPem);

      // Test the keys
      Console.WriteLine(
        Encoding.UTF8.GetString(
          rsaImportedPriv.Decrypt(
            rsaImportedPub.Encrypt(
              Encoding.UTF8.GetBytes("The quick brown fox jumps over the lazy dog"),
              RSAEncryptionPadding.Pkcs1),
            RSAEncryptionPadding.Pkcs1)));
    }
  }
}
