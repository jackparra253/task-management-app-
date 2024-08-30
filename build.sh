#!/bin/bash

# Build backend
cd backend
dotnet build
cd ..

# Build frontend
cd frontend
npm install
ng build --prod
cd ..

# Build Docker images
docker-compose build