let {lookupChar} = require('./3.Char Lookup');
let {expect} = require('chai');

describe('lookupChar', () => {

    //incorect
    it('returns undefined when worng params', () => {

        expect(lookupChar(1, 'a')).to.be.undefined
    })
    it('returns Incorrect index when biger than length', () => {

        expect(lookupChar('a', 2)).to.equal('Incorrect index')
    })
    it('returns Incorrect index when equal to length', () => {

        expect(lookupChar('a', 1)).to.equal('Incorrect index')
    })
    it('returns Incorrect index when negative', () => {

        expect(lookupChar('a', -1)).to.equal('Incorrect index')
    })
    it('returns Incorrect index when negative', () => {

        expect(lookupChar('a', -1)).to.equal('Incorrect index')
    })


    //undefined
    it('returns undefined when one param only', () => {

        expect(lookupChar(1)).to.be.undefined
        expect(lookupChar('a')).to.be.undefined
    })
    it('returns undefined when [] as a param', () => {

        expect(lookupChar(['a', 0])).to.be.undefined
    })
    it('returns undefined when index = strin length', () => {

        expect(lookupChar(['ab', 2])).to.be.undefined
    })
    it('returns undefined when two integers for params', () => {

        expect(lookupChar(1, 1)).to.be.undefined
    })
    it('returns undefined when two strings for params', () => {

        expect(lookupChar('1', '1')).to.be.undefined
    })
    it('returns undefined when floating point', () => {

        expect(lookupChar('pesh', 0.1)).to.be.undefined
    })



    //charr
    it('returns char at lower index', () => {

        expect(lookupChar('ab', 0)).to.equal('a')
    })
    it('returns char at upper index', () => {

        expect(lookupChar('ab', 1)).to.equal('b')
    })
    
})