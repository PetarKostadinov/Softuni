const { Schema, model, Types } = require('mongoose');
const { isEmail } = require('validator');

//TODO add User properties and validation according to assignment
const userSchema = new Schema({
    
    username: {
        type: String, minlength: [5, 'The username should be at least five characters long']
    },
    email: { type: String, minlength: [10, 'The email should be at least ten character long'] },
    hashedPassword: { type: String,  minlength: [4, 'The password should be at least four characters long'] },
   
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




// email: { type: String, required: [true, 'Email is required'], validate: [isEmail, 'Invalid email'] },
// username: {
//     type: String, required: [true, 'Username is required'],
//     validate: { validator: (value) => onlyLettersAndNumbers(value),
//     message: 'Username may contains only English letters and numbers' }
// },
// hashedPassword: { type: String, required: [true, 'Password is required'] },
// booked: { type: [Types.ObjectId], ref: 'User', default: [] },
// offeredHotels: { type: [Types.ObjectId], ref: 'User', default: [] },