Please follow the steps to run the application:
1. Run the code and it will open swagger to use generate pdf method.
2. Click on authorize and fill api key. Test api key is : 9b0c0dcf118741ff8e40d06da97da8cc
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


Thanks 