let expect = require('chai').expect;

function validateRequest(request) {
    describe("Request Validation", function () {
        it('Should return method GET or POST or DELETE or CONNECT', function () {
            expect(request.method).to.satisfy(function (method) {
                return (method === 'GET' || method === 'POST' || method === 'DELETE' || method === 'CONNECT');
            }, 'Invalid request header: Invalid Method');
        });

        it('Uri should contain only alphanumeric latin characters and periods or asterisk', function () {
            expect(request.uri).to.match(/^([a-zA-Z.]+)$|^\*$/, 'Invalid request header: Invalid URI');
        });

        it('Version should be HTTP/0.9 or HTTP/1.0 or HTTP/1.1 or HTTP/2.0', function () {
            expect(request.version).to.satisfy(function (version) {
                return (version === 'HTTP/0.9' || version === 'HTTP/1.0' || version === 'HTTP/1.1' || version === 'HTTP/2.0');
            }, 'Invalid request header: Invalid Version')
        });

        it('Should not contain any special character of this list (<, >, \\, &, \', ") ', function () {
                expect(request.message).to.match(/^[^\<>\&\'"]*$/, 'Invalid request header: Invalid Message');
        });
    });

    console.log(request);
}

validateRequest({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
});
