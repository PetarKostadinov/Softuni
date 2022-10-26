function attachEventsListeners() {

    const obj = {

        days: 1,
        hours: 24,
        minutes: 1440,
        seconds: 86400
    };

    function convert(value, unit){

        const inDays = value / obj[unit];

        return {

            days: inDays,
            hours: inDays * obj.hours,
            minutes: inDays * obj.minutes,
            seconds: inDays * obj.seconds
        };

    };

    const inputDays = document.getElementById('days');
    const inputHours = document.getElementById('hours');
    const inputMinutes = document.getElementById('minutes');
    const inputSeconds = document.getElementById('seconds');

    document.getElementById('daysBtn').addEventListener('click', onConvert);
    document.getElementById('hoursBtn').addEventListener('click', onConvert);
    document.getElementById('minutesBtn').addEventListener('click', onConvert);
    document.getElementById('secondsBtn').addEventListener('click', onConvert);

    function onConvert (event){

        const input = event.target.parentElement.querySelector('input[type="text"]');

        const time = convert(Number(input.value), input.id);
        
        inputDays.value = time.days;
        inputHours.value = time.hours;
        inputMinutes.value = time.minutes;
        inputSeconds.value = time.seconds;
    };



    
}