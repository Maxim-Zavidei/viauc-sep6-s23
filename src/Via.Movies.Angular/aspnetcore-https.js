// This script sets up HTTPS for the application using the ASP.NET Core HTTPS certificate
const fs = require('fs');
const spawn = require('child_process').spawn;
const path = require('path');

// Determine the base folder for storing HTTPS certificates based on the current environment
const baseFolder =
	process.env.APPDATA !== undefined && process.env.APPDATA !== '' ? `${process.env.APPDATA}/ASP.NET/https` : `${process.env.HOME}/.aspnet/https`;

// Get the certificate name from the command line arguments or from the npm package name
const certificateArg = process.argv.map(arg => arg.match(/--name=(?<value>.+)/i)).filter(Boolean)[0];
const certificateName = certificateArg ? certificateArg.groups.value : process.env.npm_package_name;

// If a valid certificate name is not provided, log an error message and exit the script
if (!certificateName) {
	console.error('Invalid certificate name. Run this script in the context of an npm/yarn script or pass --name=<<app>> explicitly.')
	process.exit(-1);
}

// Set the paths for the certificate and private key files
const certFilePath = path.join(baseFolder, `${certificateName}.pem`);
const keyFilePath = path.join(baseFolder, `${certificateName}.key`);

// If the certificate and private key files do not exist, create them using the 'dotnet dev-certs' command
if (!fs.existsSync(certFilePath) || !fs.existsSync(keyFilePath)) {
	spawn('dotnet', [
		'dev-certs',
		'https',
		'--export-path',
		certFilePath,
		'--format',
		'Pem',
		'--no-password',
	], { stdio: 'inherit', })
		.on('exit', (code) => process.exit(code));
}
