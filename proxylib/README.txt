����������� �����, ������ � ����� ������, ������������� � .dll ����������� � bin ������� ����������

� ���������� � web.config ��������

<system.net> 
    <defaultProxy enabled="true" useDefaultCredentials="false">
      <module type = "MyCorpAssembly.MyCorpProxy, MyCorpAssembly" />
    </defaultProxy>
</system.net> 