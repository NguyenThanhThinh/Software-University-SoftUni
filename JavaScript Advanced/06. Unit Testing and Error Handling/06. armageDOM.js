let expect = require('chai').expect;
let jsdom = require('jsdom-global')();
let $ = require('jquery');

function nuke(selector1, selector2) {
    if (selector1 === selector2) return;
    $(selector1).filter(selector2).remove();
}

describe('Test function nuke', function () {
    let targetHtml;
    beforeEach(function () {
        document.body.innerHTML = `<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>ArmageDOM</title>
</head>
<body>
<div id="target">
    <div class="nested target">
        <p>This is some text</p>
    </div>
    <div class="target">
        <p>Empty div</p>
    </div>
    <div class="inside">
        <span class="nested">Some more text</span>
        <span class="target">Some more text</span>
    </div>
</div>
</body>
</html>`;
        targetHtml = $('#target');
    });

    it('Should does nothing if first selector is invalid', function () {
        let selector1 = 2;
        let selector2 = $('.inside');
        let oldHtml = targetHtml.html();
        nuke(selector1, selector2);
        expect(targetHtml.html()).to.equal(oldHtml);
    });
    it('Should does nothing if second selector is invalid', function () {
        let selector1 = $('.target');
        let selector2 = 2;
        let oldHtml = targetHtml.html();
        nuke(selector1, selector2);
        expect(targetHtml.html()).to.equal(oldHtml);
    });
    it('Should does nothing if both selectors are equal', function () {
        let selector1 = $('.target');
        let oldHtml = targetHtml.html();
        nuke(selector1, selector1);
        expect(targetHtml.html()).to.equal(oldHtml);
    });
    it('Should remove all nodes if selectors are valid and not equal', function () {
        let selector1 = $('.nested');
        let selector2 = $('.target');
        let oldHtml = targetHtml.html();
        nuke(selector1, selector2);
        expect(targetHtml.html()).to.not.equal(oldHtml);
    });
});