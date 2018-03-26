let expect = require('chai').expect;

function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

describe('lookUpChar', function () {
    it('Should return undefined if the first parameter is not a string', function () {
        expect(lookupChar(4, 4)).to.equal(undefined);
    });

    it('Should return undefined if the second parameter is floating point number', function () {
       expect(lookupChar('test', 2.2)).to.equal(undefined);
    });

    it('Should return "Incorrect index" if the first parameter is empty string', function () {
        expect(lookupChar('', 1)).to.equal('Incorrect index');
    });

    it('Should return undefined if the second parameter is not an integer', function () {
        expect(lookupChar('test', '3')).to.equal(undefined);
    });

    it('Should return "Incorrect index" if index value is bigger than the string length', function () {
        expect(lookupChar('test', 7)).to.equal('Incorrect index');
    });

    it('Should return "Incorrect index" if index value is equal to the string length', function () {
        expect(lookupChar('test', 4)).to.equal('Incorrect index');
    });

    it('Should return "Incorrect index" if index value is negative number', function () {
        expect(lookupChar('test', -1)).to.equal('Incorrect index');
    });

    it('Should return char "t" with string "test" and index "3"', function () {
        expect(lookupChar('test', 3)).to.equal('t');
    });

    it('Should return "a" with string "apple" and index "0"', function () {
        expect(lookupChar('apple', 0)).to.equal('a');
    });
});