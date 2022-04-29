/**
 * Получает сумму и дату последней сделки через обращение к Web сервису.
 */
$.ajax({
    type: 'GET',
    url: 'https://localhost:44312/api/trade/last',
    dataType: 'json',
    success: function (trade) {
        let created = document.getElementById('Created');
        let amount = document.getElementById('Amount');
        var utcDate = new Date(trade.Created);
        var locaDate = new Date(utcDate.getTime() - (utcDate.getTimezoneOffset() * 60 * 1000));

        created.innerHTML = "Последняя дата сделки - " + locaDate.toLocaleString();
        amount.innerHTML = "Сумма - " + trade.Amount;
    }, 
    error: function (result) {
        alert('Ошибка выполнения');
    }
});