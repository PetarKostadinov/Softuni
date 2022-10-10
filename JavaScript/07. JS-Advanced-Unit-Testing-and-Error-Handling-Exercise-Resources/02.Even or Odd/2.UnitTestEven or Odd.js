let { isOddOrEven } = require('./2.Even or Odd');
let { assert } = require('chai');

describe('isUndefined', () => {

    it('returns undefined when not a string given', () => {
        assert.equal(isOddOrEven(1), undefined)
    })
    it('returns undefined when not a string given', () => {
        assert.equal(isOddOrEven({}), undefined)
    })

    it('returns undefined when not a string given', () => {
        assert.equal(isOddOrEven([]), undefined)
    })
    it('returns undefined when not a string given', () => {
        assert.equal(isOddOrEven({ name: 'Pesho' }), undefined)
    })

})

describe('isOddOrEven', () => {

    it('returns even when even', () => {
        assert.equal(isOddOrEven('ab'), "even")
    })
    it('returns odd when odd', () => {
        assert.equal(isOddOrEven('abc'), "odd")
    })

})

