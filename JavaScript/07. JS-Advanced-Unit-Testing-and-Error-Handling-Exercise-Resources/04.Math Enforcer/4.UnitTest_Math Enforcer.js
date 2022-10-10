let {mathEnforcer} = require ('./4.Math Enforcer');
let {expect} = require('chai');

describe('mathEnforcer', () => {
    describe('mathEnforcer.addFive', () => {

        it('returns undefined if not a number', () => {

            expect(mathEnforcer.addFive('1')).to.be.undefined
        })
        it('returns undefined if not a number', () => {

            expect(mathEnforcer.addFive('one')).to.be.undefined
        })
        it('returns number + 5', () => {

            expect(mathEnforcer.addFive(1)).to.equal(6)
            expect(mathEnforcer.addFive(-5)).to.equal(0)
            expect(mathEnforcer.addFive(-6)).to.equal(-1)
            expect(mathEnforcer.addFive(0.1)).to.be.closeTo(5.1, 0.00001)
            expect(mathEnforcer.addFive(-0.1)).to.be.closeTo(4.9, 0.00001)
        })
    })

    describe('mathEnforcer.subtractTen', () => {

        it('returns undefined if not a number', () => {

            expect(mathEnforcer.subtractTen('1')).to.be.undefined
            expect(mathEnforcer.subtractTen('one')).to.be.undefined
        })
        it('returns number - 10', () => {

            expect(mathEnforcer.subtractTen(10)).to.equal(0)
            expect(mathEnforcer.subtractTen(-10)).to.equal(-20)
            expect(mathEnforcer.subtractTen(1.123)).to.be.closeTo(-8.877, 0.00001)
            expect(mathEnforcer.subtractTen(-1.123)).to.be.closeTo(-11.123, 0.00001)
        })
    })

    describe('mathEnforcer.sum', () => {

        it('returns undefined if not a numbers', () => {

            expect(mathEnforcer.sum('1', 1)).to.be.undefined
            expect(mathEnforcer.sum(1, '1')).to.be.undefined
            expect(mathEnforcer.sum('1', '1')).to.be.undefined
            expect(mathEnforcer.sum('one', 'one')).to.be.undefined
        })
        it('returns undefined if [] as numbers', () => {

            expect(mathEnforcer.sum([1, 1])).to.be.undefined
        })
        it('returns number the sum of elements', () => {

            expect(mathEnforcer.sum(1, 1)).to.equal(2)
            expect(mathEnforcer.sum(1, 1.1)).to.equal(2.1)
            expect(mathEnforcer.sum(1.1, 1)).to.equal(2.1)
            expect(mathEnforcer.sum(1.1, 1.1)).to.equal(2.2)
            expect(mathEnforcer.sum(2, -1)).to.equal(1)
            expect(mathEnforcer.sum(-1, -1)).to.equal(-2)
            expect(mathEnforcer.sum(-2, 1)).to.equal(-1)
            
            
        })
    })
})    