function onEdit(e) {
  Logger.log(e);

  // Получаем диапазон ячеек, в которых произошли изменения
  // https://developers.google.com/apps-script/reference/spreadsheet/range
  var range = e.range;

  // Лист, на котором производились изменения
  // https://developers.google.com/apps-script/reference/spreadsheet/sheet
  var sheet = range.getSheet();

  // Проверяем, нужный ли это нам лист
  Logger.log(sheet.getName());
  if (sheet.getName() != 'Перевод текста') {
    return false;
  }

  // Переводить необходимо текст, введённый только в первую колонку.
  // Проверяем стартовую позицию диапазона
  Logger.log(range.getColumn());
  if  (range.getColumn() != 1) {
    return false;
  }

  for (var i = 1; i <= range.getNumRows(); i++) {
    var cell = range.getCell(
      i, // номер строки
      1 // номер колонки
    );

    // Получаем текст на русском
    var russianText = cell.getValue();

    // Переводим текст на английский
    // https://developers.google.com/apps-script/reference/language/language-app
    var translatedText = LanguageApp.translate(
      russianText, // текст
      'ru', // с какого языка переводим
      'en' // на какой язык переводим
    );

    // Вставляем переведённый текст во вторую колонку
    sheet.getRange(
      cell.getRowIndex(), // номер строки
      2 // номер столбца
    ).setValue(translatedText);
  }

}
