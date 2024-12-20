# Use the official Node.js image as the base image
FROM node:22

# Set the working directory inside the container
WORKDIR /app

COPY package*.json ./

COPY fix-primeng.sh ./

RUN chmod +x fix-primeng.sh

# Install dependencies
RUN npm install

COPY . .

RUN npm install -g @angular/cli

# Expose the default Angular development server port
EXPOSE 4200

# Command to run the Angular app in development mode
CMD ["ng", "serve", "--host", "0.0.0.0"]
