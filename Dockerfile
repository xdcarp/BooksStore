#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY ["BookStore/BookStore.csproj", "BookStore/"]
RUN dotnet restore "BookStore/BookStore.csproj"
COPY . .
WORKDIR "/src/BookStore"
RUN dotnet build "BookStore.csproj" -c Release -o /app
#test failed for running the migration keep investigating
#RUN dotnet ef database update

FROM build AS publish
RUN dotnet publish "BookStore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BookStore.dll"]
