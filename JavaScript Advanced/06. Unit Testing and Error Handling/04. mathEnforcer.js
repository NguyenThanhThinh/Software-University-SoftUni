let expect = require('chai').expect;

let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

describe('Test function mathEnfore', function () {
    describe('addFive', function () {
        it('Should return undefined using addFive function if parameter is not a number', function () {
            expect(mathEnforcer.addFive('5')).to.be.undefined;
        });

        it('Should add 5 to passed parameter using addFive function if we pass a positive number', function () {
            expect(mathEnforcer.addFive(5)).to.equal(10);
        });

        it('Should return 0 using function addFive with parameter -5', function () {
            expect(mathEnforcer.addFive(-5)).to.equal(0);
        });

        it('Should return correct result (up to 0.01 precision) using function addFive with floating point number', function () {
            expect(mathEnforcer.addFive(-5.01)).to.be.closeTo(0, 0.01);
        });
    });

    describe('substractTen', function () {
        it('Should return undefined using subtractTen function if parameter is not a number', function () {
            expect(mathEnforcer.subtractTen('5')).to.be.undefined;
        });

        it('Should substract 10 to passed parameter using subtractTen function if we pass a positive number', function () {
            expect(mathEnforcer.subtractTen(10)).to.equal(0);
        });

        it('Should return -20 using function subtractTen with parameter -10', function () {
            expect(mathEnforcer.subtractTen(-10)).to.equal(-20);
        });

        it('Should return correct result (up to 0.01 precision) using function subtractTen with floating point number', function () {
            expect(mathEnforcer.subtractTen(10.01)).to.be.closeTo(0, 0.01);
        });
    });

    describe('sum', function () {
        it('Should return undefined if first parameter of function "sum" is not a number', function () {
            expect(mathEnforcer.sum('2', 2)).to.be.undefined;
        });

        it('Should return undefined if second parameter of function "sum" is not a number', function () {
            expect(mathEnforcer.sum(2, '2')).to.be.undefined;
        });

        it('Should return the sum of both parameters if they are numbers', function () {
            expect(mathEnforcer.sum(2, 2)).to.equal(4);
        });

        it('Should return correct result with first param negative num and second param positive num', function () {
            expect(mathEnforcer.sum(-5, 4)).to.equal(-1);
        });

        it('Should return correct result with first param positive num and second param negative num', function () {
            expect(mathEnforcer.sum(5, -4)).to.equal(1);
        });

        it('Should return correct result when both params are positive numbers', function () {
            expect(mathEnforcer.sum(5, 4)).to.equal(9);
        });

        it('Should return correct result when both params are negative numbers', function () {
            expect(mathEnforcer.sum(-5, -4)).to.equal(-9);
        });

        it('Should return correct result (up to 0.01 precision) using function sum with floating point numbers', function () {
            expect(mathEnforcer.sum(5.014, 1.013)).to.be.closeTo(6.02, 0.01);
        });
    });
});