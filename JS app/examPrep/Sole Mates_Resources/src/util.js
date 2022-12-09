export function getUserData() {
    const data = JSON.parse(sessionStorage.getItem('userData'));
    return data;
}

export function setUserData(data) {
    sessionStorage.setItem('userData', JSON.stringify(data));
}

export function clearUserData() {
    sessionStorage.removeItem('userData');
}

export function createSubmitHandler(calback){
    return function (event){
        event.preventDefault();
        const formData = new FormData(event.target);
        const data = Object.fromEntries(formData);

        calback(data);
    }
}