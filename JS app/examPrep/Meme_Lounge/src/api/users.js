import { clearUserData, setUserData } from "../util.js";
import { get, post } from "./api.js";


export async function login(email, password) {
    const result = await post('/users/login', { email, password });

    setUserData({
        id: result._id,
        username: result.username,
        email: result.email,
        accessToken: result.accessToken,
        gender: result.gender
    })
}

export async function register( username, email, password, gender ) {
    const result = await post('/users/register', { username, email, password, gender });

    setUserData({
        id: result._id,
        username: result.username,
        email: result.email,
        accessToken: result.accessToken,
        gender: result.gender
    })
}

export async function logout() {
    get('/users/logout');
    clearUserData();
}

