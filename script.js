import http from 'k6/http';
export default function () {
    const url = `https://localhost:5001/${__ENV.ENDPOINT}`;

    // check the username in the
    // database.db file for a match
    const payload = "{\"username\":\"Mona.Raynor_500\",\"password\":\"\",\"passwordConfirmation\":\"\",\"subscriptionLevel\":\"\"}";
    
    const params = {
        headers: {
            'Content-Type': 'application/json'
        },
    };

    http.post(url, payload, params);
}