// This is my journal for April 28.
// Today I learnt how to create a simple calculator that shows the total score and average over 5 assignments of 4 different students.

// code:
int currentAssignments = 5;

int sophia1 = 93;
int sophia2 = 87;
int sophia3 = 98;
int sophia4 = 95;
int sophia5 = 100;

int nicolas1 = 80;
int nicolas2 = 83;
int nicolas3 = 82;
int nicolas4 = 88;
int nicolas5 = 85;

int zahirah1 = 84;
int zahirah2 = 96;
int zahirah3 = 73;
int zahirah4 = 85;
int zahirah5 = 79;

int jeong1 = 90;
int jeong2 = 92;
int jeong3 = 98;
int jeong4 = 100;
int jeong5 = 97;

int sophia = sophia1 + sophia2 + sophia3 + sophia4 + sophia5;
int nicolas = nicolas1 + nicolas2 + nicolas3 + nicolas4 + nicolas5;
int zahirah = zahirah1 + zahirah2 + zahirah3 + zahirah4 + zahirah5;
int jeong = jeong1 + jeong2 + jeong3 + jeong4 + jeong5;

Console.WriteLine($"Sophia Toal Score: {sophia}     Sophia Average:{sophia / 5}");
Console.WriteLine($"nicolas Toal Score: {nicolas}     nicolas Average:{nicolas / 5}");
Console.WriteLine($"zahirah Toal Score: {zahirah}     zahirah Average:{zahirah / 5}");
Console.WriteLine($"jeong Toal Score: {jeong}     jeong Average:{jeong / 5}");

