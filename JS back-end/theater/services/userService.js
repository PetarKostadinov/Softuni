const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const User = require('../models/User');

const JWT_SECRET = 'dfgerhsrtdge433';

async function register(username, password) {

    const existing = await User.findOne({ username }).collation({ locale: 'en', strength: 2 });
    if (existing) {
        throw new Error('Username is taken');
    }

    const hashedPassword = await bcrypt.hash(password, 10);
    const user = await User.create({
        username,
        hashedPassword,
        likedPlays: []
    });

    //TODO see assignment if registration creates user session

    const token = createSession(user);

    return token;
}

async function login(username, password) {
    const user = await User.findOne({ username }).collation({ locale: 'en', strength: 2 });
    if (!user) {
        throw new Error('Incorect username or password');
    }

    const hasMatch = await bcrypt.compare(password, user.hashedPassword);

    if (hasMatch == false) {
        throw new Error('Incorect username or password');
    }

    const token = createSession(user);
    return token;
}

function createSession({ _id, username, likedPlays }) {
    const payload = {
        _id,
        username,
        likedPlays
    };

    const token = jwt.sign(payload, JWT_SECRET);

    return token;
}

function verifyToken(token) {

    return jwt.verify(token, JWT_SECRET);
}
module.exports = {
    register,
    login,
    verifyToken
}