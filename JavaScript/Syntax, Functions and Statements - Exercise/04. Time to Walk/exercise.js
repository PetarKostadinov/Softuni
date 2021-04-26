
function solve(steps, footprintMeeters, kmPerHour) {

    let meetersPerSecond = kmPerHour * 1000 / 3600;
    let distance = steps * footprintMeeters;
    let rest = Math.floor(distance / 500) * 60;
    let time = distance / meetersPerSecond + rest;

    let hours = Math.floor(time / 3600).toFixed(0).padStart(2, "0");
    time %= 3600;
    let minutes = Math.floor(time / 60).toFixed(0).padStart(2, "0");
    let seconds = (time % 60).toFixed(0).padStart(2, "0");

    time = `${hours}:${minutes}:${seconds}`;

    return time;
}

console.log(solve(4000, 0.60, 5));
console.log(solve(2564, 0.70, 5.5));