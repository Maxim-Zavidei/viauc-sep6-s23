const { env } = require('process');

// Determine the target URL for the proxy based on environment variables
// This target URL should point to Via.Movies.Api
const target = env.ASPNETCORE_HTTPS_PORT
	? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`
	: env.ASPNETCORE_URLS
		? env.ASPNETCORE_URLS.split(';')[0]
		: 'http://localhost:4798';

// Define the proxy configuration object
const PROXY_CONFIG = [
	{
		// Specify the API endpoints that should be proxied to Via.Movies.Api
		context: [
			"/api/wheatherforecast/"
		],
		// Set the target URL for the proxy, which should point Via.Movies.Api
		target: target,
		// Disable SSL certificate verification for the proxy, which is useful for local development
		secure: false,
		// Set custom headers for the proxy requests
		headers: {
			Connection: 'Keep-Alive'
		}
	}
]

// Export the proxy configuration object as a module to be used
// by Via.Movies.Angular in angular.json file
module.exports = PROXY_CONFIG;
