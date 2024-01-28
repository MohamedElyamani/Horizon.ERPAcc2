#!/bin/bash

if [[ ! -d certs ]]
then
    mkdir certs
    cd certs/
    if [[ ! -f localhost.pfx ]]
    then
        dotnet dev-certs https -v -ep localhost.pfx -p 25fcd6d8-5774-4a2b-9459-deb1da395c43 -t
    fi
    cd ../
fi

docker-compose up -d
