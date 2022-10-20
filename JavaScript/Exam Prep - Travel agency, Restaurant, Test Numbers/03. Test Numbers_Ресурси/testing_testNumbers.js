
const { testNumbers } = require('./testNumbers')
const { expect } = require('chai')



describe("testNumbers …", function () {

    describe("sumNumbers", function () {

        it("returns undefined if not a number", function () {
            expect(testNumbers.sumNumbers('1', 1)).to.be.undefined
            expect(testNumbers.sumNumbers('1', '1')).to.be.undefined
            expect(testNumbers.sumNumbers(1, '1')).to.be.undefined
        });
        it("returns sum of numbers", function () {
            expect(testNumbers.sumNumbers(-1, 1)).to.equal('0.00')
            expect(testNumbers.sumNumbers(-1, -1)).to.equal('-2.00')
            expect(testNumbers.sumNumbers(1, -1)).to.equal('0.00')
        });
        it("returns sum of numbers", function () {
            expect(testNumbers.sumNumbers(-1, 1)).to.equal('0.00')
            expect(testNumbers.sumNumbers(-1, -1)).to.equal('-2.00')
            expect(testNumbers.sumNumbers(1, -1)).to.equal('0.00')
        });
    });

    describe("numberChecker(input) ", function () {

        it("returns even or odd", function () {
            expect(testNumbers.numberChecker('1')).to.equal('The number is odd!')
            expect(testNumbers.numberChecker('-1')).to.equal('The number is odd!')
            expect(testNumbers.numberChecker('0')).to.equal('The number is even!')
        });

        it("throws error if NaN", () => {
            expect(() => testNumbers.numberChecker('a')).to.throw(Error, 'The input is not a number!')
           expect(() => testNumbers.numberChecker('b')).to.throw(Error, 'The input is not a number!')
           expect(() => testNumbers.numberChecker('e')).to.throw(Error, 'The input is not a number!')
        });
      
    });

    describe("averageSumArray(arr) ", function () {

        it("returns averagge sum", function () {
            expect(testNumbers.averageSumArray([1, 1, 1, 1])).to.equal(1)
            expect(testNumbers.averageSumArray([-1, 1, 1, 1])).to.equal(0.5)
            expect(testNumbers.averageSumArray([1, 1, 1, 0.5])).to.equal(0.875)
        });

        // it("returns undefined if not a number", () => {
        //     expect(() => testNumbers.numberChecker('a')).to.throw(Error, 'The input is not a number!')
        //    expect(() => testNumbers.numberChecker('b')).to.throw(Error, 'The input is not a number!')
        //    expect(() => testNumbers.numberChecker('e')).to.throw(Error, 'The input is not a number!')
        // });
      
    });
    // TODO: …
});
