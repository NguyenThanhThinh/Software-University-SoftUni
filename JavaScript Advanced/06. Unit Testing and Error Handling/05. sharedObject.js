let expect = require('chai').expect;
let jsdom = require('jsdom-global')();
let $ = require('jquery');

document.body.innerHTML = `<!DOCTYPE html>
<html lang="en">
    <head>
    <meta charset="UTF-8">
    <title>Shared Object</title>
</head>
<body>
<div id="wrapper">
    <input type="text" id="name">
    <input type="text" id="income">
    </div>
    </body>
    </html>`;

let sharedObject = {
    name: null,
    income: null,
    changeName: function (name) {
        if (name.length === 0) {
            return;
        }
        this.name = name;
        let newName = $('#name');
        newName.val(this.name);
    },
    changeIncome: function (income) {
        if (!Number.isInteger(income) || income <= 0) {
            return;
        }
        this.income = income;
        let newIncome = $('#income');
        newIncome.val(this.income);
    },
    updateName: function () {
        let newName = $('#name').val();
        if (newName.length === 0) {
            return;
        }
        this.name = newName;
    },
    updateIncome: function () {
        let newIncome = $('#income').val();
        if (isNaN(newIncome) || !Number.isInteger(Number(newIncome)) || Number(newIncome) <= 0) {
            return;
        }
        this.income = Number(newIncome);
    }
};

describe('Test function sharedObject', function () {
    describe('Initial values of properties name and income', function () {
        it('Object property name should have initial value null', function () {
            expect(sharedObject.name).to.be.null;
        });

        it('Object property income should have initial value null', function () {
            expect(sharedObject.income).to.be.null;
        });
    });

    describe('Function changeName', function () {
        it('No changes should be made if passed parameter is empty string', function () {
            let previousValue = sharedObject.name;
            sharedObject.changeName('');
            expect(sharedObject.name).to.equal(previousValue);
        });

        it('Parameter name should be changed successfully with the passed non-empty string', function () {
            let name = 'Sev';
            sharedObject.changeName(name);
            expect(sharedObject.name).to.equal(name);
        });

        describe('Name input tests', function () {
            it('No changes should be made if passed parameter is empty string', function () {
                let previousValue = $('#name').val();
                sharedObject.changeName('');
                expect($('#name').val()).to.equal(previousValue);
            });

            it('Name textbox value should be changed successfully with the passed non-empty string', function () {
                let name = 'Sev';
                sharedObject.changeName(name);
                expect($('#name').val()).to.equal(name);
            });
        });
    });

    describe('Function changeIncome', function () {
        it('Property income should not change when passed parameter is string', function () {
            let previousIncome = sharedObject.income;
            sharedObject.changeIncome('4');
            expect(previousIncome).to.equal(sharedObject.income);
        });

        it('Property income should not change when passed parameter is floating-point', function () {
            sharedObject.changeIncome(4);
            let previousIncome = sharedObject.income;
            sharedObject.changeIncome(4.14);
            expect(sharedObject.income).to.equal(previousIncome);
        });

        it('Property income should not change when passed parameter is negative number', function () {
            let previousIncome = sharedObject.income;
            sharedObject.changeIncome(-5);
            expect(sharedObject.income).to.equal(previousIncome);
        });

        it('Property income should not change when passed parameter is zero', function () {
            let previousIncome = sharedObject.income;
            sharedObject.changeIncome(0);
            expect(sharedObject.income).to.equal(previousIncome);
        });

        it('Property income should change successfully when passed parameter is positive number', function () {
            let param = 5;
            sharedObject.changeIncome(param);
            expect(sharedObject.income).to.equal(param);
        });

        describe('Income input tests', function () {
            it('Income input should not change when passed parameter is string', function () {
                let previousIncome = $('#income').val();
                sharedObject.changeIncome('4');
                expect(previousIncome).to.equal($('#income').val());
            });

            it('Income input should not change when passed parameter is floating-point', function () {
                sharedObject.changeIncome(4);
                let previousIncome = $('#income').val();
                sharedObject.changeIncome(4.14);
                expect($('#income').val()).to.equal(previousIncome);
            });

            it('Income input should not change when passed parameter is negative number', function () {
                let previousIncome = $('#income').val();
                sharedObject.changeIncome(-5);
                expect($('#income').val()).to.equal(previousIncome);
            });

            it('Income input should not change when passed parameter is zero', function () {
                let previousIncome = $('#income').val();
                sharedObject.changeIncome(0);
                expect($('#income').val()).to.equal(previousIncome);
            });

            it('Income input should change successfully when passed parameter is positive number', function () {
                let param = 5;
                sharedObject.changeIncome(param);
                expect(Number($('#income').val())).to.equal(param);
            });
        });
    });

    describe('Function updateName', function () {
        it('Property name should not change when passed parameter is empty string', function () {
            let name = $('#name');
            name.val('Sevdalin');
            let previousNameValue = name.val();
            sharedObject.updateName();
            name.val('');
            sharedObject.updateName();
            expect(sharedObject.name).to.equal(previousNameValue);
        });

        it('Property name should change successfully when passed parameter is non-empty string', function () {
            sharedObject.changeName('Sevdalin');
            let name = $('#name');
            let nameNewValue = 'Kiril';
            name.val(nameNewValue);
            sharedObject.updateName();
            expect(sharedObject.name).to.equal(nameNewValue);
        });
    });

    describe('Function updateIncome', function () {
        it('Property income should not change when passed parameter is string', function () {
            sharedObject.changeIncome(1);
            let previousIncome = sharedObject.income;
            $('#income').val('four');
            sharedObject.updateIncome();
            expect(previousIncome).to.equal(sharedObject.income);
        });

        it('Property income should not change when passed parameter is floating-point', function () {
            sharedObject.changeIncome(2);
            let previousIncome = sharedObject.income;
            $('#income').val(4.14);
            sharedObject.updateIncome();
            expect(previousIncome).to.equal(sharedObject.income);
        });

        it('Property income should not change when passed parameter is negative number', function () {
            sharedObject.changeIncome(3);
            let previousIncome = sharedObject.income;
            $('#income').val(-2);
            sharedObject.updateIncome();
            expect(previousIncome).to.equal(sharedObject.income);
        });

        it('Property income should not change when passed parameter is zero', function () {
            sharedObject.changeIncome(4);
            let previousIncome = sharedObject.income;
            $('#income').val(0);
            sharedObject.updateIncome();
            expect(previousIncome).to.equal(sharedObject.income);
        });

        it('Property income should change successfully when passed parameter is positive number', function () {
            let num = 5;
            $('#income').val(num);
            sharedObject.updateIncome();
            expect(num).to.equal(sharedObject.income);
        });
    });
});