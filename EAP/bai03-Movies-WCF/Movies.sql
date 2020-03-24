use Exam
go
IF OBJECT_ID('dbo.Genre', 'U') IS NOT NULL
  DROP TABLE dbo.Genre
CREATE TABLE Genre(
	GenreId INT PRIMARY KEY IDENTITY (1,1),	/* định danh cục bộ */
	GenreName NVARCHAR(100) NOT NULL /* Thể Loại Phim */
)
ON [PRIMARY]
GO

INSERT INTO Genre(GenreName) VALUES
 (N'Science Fiction Film'),	/* Khoa học giả tưởng */
 (N'Romantic Disaster Film'), /* Lãng mạn */
 (N'Opera Film'),	/* Truyền hình nhiều tập */
 (N'Super Hero Film'), /* Siêu anh hùng */
 (N'Action Film'),	/* Hành động */
 (N'3D Animated Feature Film'), /* Hoạt hình 3D */
 (N'Musical') /* Ca nhạc kịch */
GO

/* tạo bảng PHIM */
IF OBJECT_ID('dbo.Movie', 'U') IS NOT NULL
  DROP TABLE dbo.Movie
CREATE TABLE Movie(
	MovieId INT PRIMARY KEY IDENTITY (1,1),
	Title NVARCHAR(100) NOT NULL, /* Tựa Đề Phim (3-32 kí tự) */
	ReleaseDate DATE NOT NULL,	/* Ngày Phát Hành yyyy-mm-dd */
	RunningTime INT NOT NULL,	/* Thời Lượng từ 60-240 phút (minutes) */
	GenreId INT NOT NULL FOREIGN KEY REFERENCES Genre(GenreId), /* khóa ngoại tham chiếu sang bảng thể loại phim Genre */
	BoxOffice MONEY NOT NULL, /* Doanh Thu Phòng vé từ 0.1 đến 3 tỉ đô la (billion dollars) */
)
ON [PRIMARY]
GO

INSERT INTO Movie(Title, ReleaseDate, RunningTime, GenreId, BoxOffice) VALUES
 (N'Avatar', '2009-12-10', 161, 1, 2.788),
 (N'Titanic', '1997-11-01', 195, 2, 2.187),
 (N'Star Wars: The Force Awakens', '2015-12-14', 135, 3, 1.763),
 (N'Jurassic World', '2015-05-29', 124, 1, 1.669),
 (N'Marvel Avengers', '2012-04-11', 143, 4, 1.520),
 (N'Fast And Furius', '2015-04-01', 137, 5, 1.515),
 (N'Frozen', '2013-11-19', 102, 6, 1.276),
 (N'Iron Man 3', '2013-05-03', 130, 4, 1.215),
 (N'Minions', '2015-06-11', 91, 6, 1.157),
 (N'Transformers', '2007-06-12', 144, 1, 0.71),
 (N'High School Musical', '2006-01-20', 98, 6, 0.4),
 (N'Gangnam Style', '2012-07-15', 93, 6, 0.5)
GO