вписывается логин, пароль и домен прокси, компилируется и .dll вставляется в bin проекта приложения

в приложении в web.config дописать

<system.net> 
    <defaultProxy enabled="true" useDefaultCredentials="false">
      <module type = "MyCorpAssembly.MyCorpProxy, MyCorpAssembly" />
    </defaultProxy>
</system.net> 