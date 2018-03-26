let expect = require('chai').expect;

function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

function testingIsOddOrEven() {
    describe("Function isOddOrEven Validation", function () {
        it('Should return undefined when paramater is number', function () {
            expect(isOddOrEven(7)).to.equal(undefined, "Function did not return the correct result");
        });

        it('Should return undefined when paramater is object', function () {
            expect(isOddOrEven({name: 'ivan'})).to.equal(undefined, "Function did not return the correct result");
        });

        it('Should return even with string length 4', function () {
            expect(isOddOrEven('test')).to.equal('even', "Function did not return the correct result");
        });

        it('Should return odd with string length 3', function () {
            expect(isOddOrEven('bum')).to.equal('odd', "Function did not return the correct result");
        });
    })
}

testingIsOddOrEven();