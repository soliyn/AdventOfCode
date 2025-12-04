using CSharp.Day04;

namespace CSharp.Tests.Day04.GridOfPaperTests;

public class GetNumberOfAccessedRolls
{
    [Fact]
    public void Should_Return_CorrectNumberOfAccessedRolls()
    {
        char[][] grid = new char[][]
        {
            [ '.', '.', '@', '@', '.', '@', '@', '@', '@', '.' ],
            [ '@', '@', '@', '.', '@', '.', '@', '.', '@', '@' ],
            [ '@', '@', '@', '@', '@', '.', '@', '.', '@', '@' ],
            [ '@', '.', '@', '@', '@', '@', '.', '.', '@', '.' ],
            [ '@', '@', '.', '@', '@', '@', '@', '.', '@', '@' ],
            [ '.', '@', '@', '@', '@', '@', '@', '@', '.', '@' ],
            [ '.', '@', '.', '@', '.', '@', '.', '@', '@', '@' ],
            [ '@', '.', '@', '@', '@', '.', '@', '@', '@', '@' ],
            [ '.', '@', '@', '@', '@', '@', '@', '@', '@', '.' ],
            [ '@', '.', '@', '.', '@', '@', '@', '.', '@', '.' ]
        };
        
        Assert.Equal(13, GridOfPaper.GetNumberOfAccessedRolls(grid));
    }
}