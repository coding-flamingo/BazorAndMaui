$certificateSubjectName = "CN=Coding Flamingo"
New-SelfSignedCertificate -Type Custom -Subject $certificateSubjectName  -KeyUsage DigitalSignature -FriendlyName "Coding Flamingo Self Sign" -CertStoreLocation "Cert:\CurrentUser\My" -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.3", "2.5.29.19={text}")

$cert = (Get-ChildItem cert:\CurrentUser\My   | where-object { $_.Subject -like "$certificateSubjectName" }  | Select-Object -First 1).Thumbprint

$env:Path += ";C:\Program Files\Microsoft Visual Studio\2022\Preview\Msbuild\Current\Bin" 
$env:Path += ";C:\Program Files (x86)\Windows Kits\10\App Certification Kit"

msbuild /restore /t:Publish /p:TargetFramework=net6.0-windows10.0.19041  /p:configuration=release /p:GenerateAppxPackageOnBuild=true /p:AppxPackageSigningEnabled=true /p:PackageCertificateThumbprint=$cert