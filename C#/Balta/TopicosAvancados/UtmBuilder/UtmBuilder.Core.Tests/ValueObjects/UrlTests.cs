using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects;

[TestClass]
public class UrlTests {
    
    private const string InvalidUrl = "banana";
    private const string ValidUrl = "https://www.google.com";

    [TestMethod("Deve retornar uma exceção quando a URL for invalida")]
    [TestCategory("Teste de URL")]
    public void Dado_uma_url_invalida_deve_retornar_uma_excecao() {
        try {
            var url = new Url(InvalidUrl);
            Assert.Fail();
        }
        catch (InvalidUrlException) {
            Assert.IsTrue(true);
        }
        
    }
    
    [TestMethod("Não deve retornar uma exceção quando a URL for invalida")]
    [TestCategory("Teste de URL")]
    public void Dado_uma_url_valida_deve_retornar_sucesso() {
        var url = new Url(ValidUrl);
        Assert.IsTrue(true);
    }
    
    [TestMethod]
    [DataRow("https://www.google.com", false)]
    [DataRow(" ", true)]
    [DataRow("https", true)]
    [DataRow("banana", true)]
    public void TestUrl(string link, bool expectedException) {
        if (expectedException) {
            try {
                var url = new Url(link);
                Assert.Fail();
            }
            catch (InvalidUrlException e) {
                Assert.IsTrue(true);
            }
        }
    }
}