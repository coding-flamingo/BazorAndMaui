keytool -genkey -v -keystore codingflamingo.keystore -alias mauiAppKey -keyalg RSA -keysize 2048 -validity 3000
dotnet publish MauiApp1.csproj -f:net6.0-android -c:Release /p:AndroidSigningKeyPass=mypassword /p:AndroidSigningStorePass=mypassword /p:AndroidSigningKeyStore=codingflamingo.keystore /p:AndroidSigningKeyAlias=mauiAppKey /p:AndroidKeyStore=True