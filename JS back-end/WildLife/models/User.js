const { Schema, model } = require('mongoose');

//TODO add User properties and validation according to assignment
const NAME_PATERN = /^[a-zA-Z]+$/;
const EMAIL_PATERN = /^[a-zA-Z0-9.!#$]/;


const userSchema = new Schema({
    firstName: {
        type: String, minlength: [3, 'First Namme must be atleast 3 characters long'], validate: {
            validator(value) {
                return NAME_PATERN.test(value);
            },
            message: `First Name may contains only english letters`
        }
    },
    lastName: {
        type: String, minlength: [5, 'Last Namme must be atleast 5 characters long'], validate: {
            validator(value) {
                return NAME_PATERN.test(value);
            },
            message: `Last Name may contains only english letters`
        }
    },
    email: {
        type: String, required: [true, 'Email is required'], validate: {
            validator(value) {
                return EMAIL_PATERN.test(value);
            },
            message: `Email must be valid and may contains only english letters`
        }
    },
    hashedPassword: { type: String, required: true }
});

userSchema.index({ email: 1 }, {
    unique: true,
    collation: {
        locale: 'en',
        strength: 2
    }
});

const User = model('User', userSchema);

module.exports = User;