export interface Movie {
	id: number;
	title: string;
	year: number;

	averageRating: number;

	directorId: number;
	directorName: string;
	directorBirth: number;

	imageURL?: string;
}
