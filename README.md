Description:
SecurityNews.Web 
 site where user can buy a news subscription
 user should enter credit card information and press button submit
 then SecurityNews.Web sends cryptographed request to Bank.WebApi and receive response with transaction status.

Configuration:
1. Clone the project
2. Publish Bank.WebApi and SecurityNews.Web to IIS
3. SecurityNews.Web
   update web.config file appSettings sections
   <appSettings>
    <add key="bankApiUrl" value="[Bank WebApi Url]" />
   </appSettings>
   Instead [Bank WebApi Url] add url to Bank.WebApi project published to IIS
   for example http://localhost:8005/
4. SecurityNews.Web should has /App_Data/EncryptionKeys.xml
   Bank.WebApi should has /App_Data/DecryptionKeys.xml
   this config files used for encryption and decryption
