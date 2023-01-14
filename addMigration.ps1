$param1=$args[0]

cd ./S148.Backend.Domain/
dotnet ef --startup-project ../S148.Backend/ migrations add {$param1}