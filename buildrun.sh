dotnet build -t:Run -f net8.0-android \
    -p:AdbTarget='-s R5CY136T7WH' \
    -p:AndroidSdkDirectory='/home/nexden2/Desktop/CET301/android-sdk' \
    -p:JavaSdkDirectory='/home/nexden2/Desktop/CET301/jdk' \
    -p:AcceptAndroidSdkLicenses=True
