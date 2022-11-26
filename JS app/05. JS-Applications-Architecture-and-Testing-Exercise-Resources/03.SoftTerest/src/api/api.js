
const host = 'http://localhost:3030';

async function request(method = 'get', url, data) {
    const options = {
        method,
        headers: {}
    }

    if (data != undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    const user = JSON.parse(localStorage.getItem('user'));
    if(user){
        const token = user.accessToken;
        options.headers['X-Authorization'] = token
    }

    try {
        const res = await fetch(host + url, options);
        if (res.ok != true) {
            if(res.status == 403){
                localStorage.removeItem('user');
            }
            const err = await res.json();
            throw new Error(err.message);
        }

        if (res.status == 204) {
            return res;
        } else {
            return res.json();
        }


    } catch (error) {
        alert(error.message);
        throw error;
    }
}
const get = request.bind(null, 'get')
const post = request.bind(null, 'post')
const put = request.bind(null, 'put')
const del = request.bind(null, 'delete')

export {
    get,
    post,
    put,
    del as delete
}
