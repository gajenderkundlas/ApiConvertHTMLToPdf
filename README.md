# ApiConvertHTMLToPdf
This project is used for conversion of html to pdf using api and also implemented signin and signup for providing api key.

Please follow the steps to run the application:
Open solution in VS-2022, below versions are not supported. 
1. Change connection string in appsetting.json file and also change email settings.
2. Run the code and it will open 2 projects one is api that will open swagger and one is signin and signup web app.
3. Use signup page to create new account and check your email link for verification.
2. After verification click on signin and you will see apikey and api project swagger.Click on authorize and fill api key.
3. Click on try and then paste the html in html parameter.
4. Passphrase used to protect the pdf, leave blank if you dont want to use password for pdf.
5. Use below sample inputs 
    a. Without password :
    {
      "html": "<!DOCTYPE html> <html> <style> table, th, td {   border:1px solid black; } </style> <body>  <h2>A basic HTML table</h2>  <table style='width:100%'>   <tr>     <th>Company</th>     <th>Contact</th>     <th>Country</th>   </tr>   <tr>     <td>Alfreds Futterkiste</td>     <td>Maria Anders</td>     <td>Germany</td>   </tr>   <tr>     <td>Centro comercial Moctezuma</td>     <td>Francisco Chang</td>     <td>Mexico</td>   </tr> </table>  <p>To understand the example better, we have added borders to the table.</p>  </body> </html>",
      "passphrase": ""
    }
    b. With password :
      {
          "html": "<!DOCTYPE html> <html> <style> table, th, td {   border:1px solid black; } </style> <body>  <h2>A basic HTML table</h2>  <table style='width:100%'>   <tr>     <th>Company</th>     <th>Contact</th>     <th>Country</th>   </tr>   <tr>     <td>Alfreds Futterkiste</td>     <td>Maria Anders</td>     <td>Germany</td>   </tr>   <tr>     <td>Centro comercial Moctezuma</td>     <td>Francisco Chang</td>     <td>Mexico</td>   </tr> </table>  <p>To understand the example better, we have added borders to the table.</p>  </body> </html>",
          "passphrase": "123456"
      }
6. Check the output link and paste it on browser , you will see your PDF.

Configuration that need to know: 
In appsetting you can change domain and apikey for live hosting or custom key change.

