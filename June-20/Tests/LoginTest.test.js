const {JSDOM} = require('jsdom');
const fs = require('fs');
const path = require('path');

test('Login Success Test', () => {
    const html = fs.readFileSync(path.resolve(__dirname, '../Login.html'), 'utf8');
    const script = fs.readFileSync(path.resolve(__dirname, '../script.js'), 'utf8');
    const dom = new JSDOM(html, {runScripts: "dangerously", resources: "usable"});

    var scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    dom.window.document.getElementById('txtEmail').value = "himu@gmail.com";
    dom.window.document.getElementById('txtPass').value = "himuPASS1@";
    dom.window.document.getElementById('loginBtn').click();
    const actual = dom.window.document.getElementById('loginMsg').innerHTML;
    expect(actual).toBe('logged in successfully!');
})

test('Login Fail Test', () => {
    const html = fs.readFileSync(path.resolve(__dirname, '../Login.html'), 'utf8');
    const script = fs.readFileSync(path.resolve(__dirname, '../script.js'), 'utf8');
    const dom = new JSDOM(html, {runScripts: "dangerously", resources: "usable"});

    var scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    dom.window.document.getElementById('txtEmail').value = "hima@gmail.com";
    dom.window.document.getElementById('txtPass').value = "himuPASS1@";
    dom.window.document.getElementById('loginBtn').click();
    const actual = dom.window.document.getElementById('loginMsg').innerHTML;
    expect(actual).toBe('login failed!');
})