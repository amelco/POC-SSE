const http = require('http');
const fs = require('fs');
const path = require('path');

const server = http.createServer((req, res) => {
  // Serve index.html as the default page
  if (req.url === '/' || req.url === '/index.html') {
    const filePath = path.join(__dirname, 'index.html');
    fs.readFile(filePath, (err, data) => {
      if (err) {
        res.writeHead(500, { 'Content-Type': 'text/plain' });
        res.end(`Error loading index.html: ${err}`);
      } else {
        res.setHeader('Access-Control-Allow-Origin', 'http://localhost:6001');
        res.setHeader('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE');
        res.setHeader('Access-Control-Allow-Headers', 'Content-Type');
        res.writeHead(200, { 'Content-Type': 'text/html' });
        res.end(data);
      }
    });
  } else {
    // Serve static files (e.g. CSS, JS) from the "public" directory
    const publicPath = path.join(__dirname, 'public', req.url);
    fs.readFile(publicPath, (err, data) => {
      if (err) {
        res.writeHead(404, { 'Content-Type': 'text/plain' });
        res.end('Not found');
      } else {
        // Determine the content type based on the file extension
        const ext = path.extname(req.url);
        let contentType = 'text/plain';
        switch (ext) {
          case '.html':
            contentType = 'text/html';
            break;
          case '.css':
            contentType = 'text/css';
            break;
          case '.js':
            contentType = 'text/javascript';
            break;
        }
        res.setHeader('Access-Control-Allow-Origin', 'http://localhost:6001');
        res.setHeader('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE');
        res.setHeader('Access-Control-Allow-Headers', 'Content-Type');
        res.writeHead(200, { 'Content-Type': contentType });
        res.end(data);
      }
    });
  }
});

server.listen(6001, () => {
  console.log('Server running on http://localhost:6001/');
});
