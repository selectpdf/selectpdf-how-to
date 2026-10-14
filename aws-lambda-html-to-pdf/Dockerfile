FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG NATIVE_RID=linux-x64
WORKDIR /src
COPY . .
RUN dotnet publish PdfLambda.csproj -c Release -r $NATIVE_RID --self-contained false \
    -p:NativeRid=$NATIVE_RID -o /app

# the AWS Lambda base image for .NET 10: nothing else to install
FROM public.ecr.aws/lambda/dotnet:10
COPY --from=build /app ${LAMBDA_TASK_ROOT}
CMD ["PdfLambda::PdfLambda.Function::Handler"]
