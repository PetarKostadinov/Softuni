const { Schema, model, Types } = require('mongoose');
const { isEmail } = require('validator');

//TODO add User properties and validation according to assignment
const userSchema = new Schema({
    
    username: {
        type: String, required: [true, 'Username is required'] },
    email: { type: String, required: [true, 'Email is required']},
    hashedPassword: { type: String, required: [true, 'Password is required'] },
    created: { type: [Types.ObjectId], ref: 'Photo', default: [] },
    // offeredHotels: { type: [Types.ObjectId], ref: 'User', default: [] },
});

function onlyLettersAndNumbers(str) {
    return /^[A-Za-z0-9]*$/.test(str);
}

userSchema.index({ username: 1 }, {
    collation: {
        locale: 'en',
        strength: 2
    }
});

const User = model('User', userSchema);

module.exports = User;