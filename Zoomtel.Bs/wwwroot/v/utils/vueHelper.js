Vue.filter('datetime', function (value, fmt) {
    return formatDateTime(value, fmt);
})