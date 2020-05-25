const students = []
const rows = 5
const cols = 3

// Temp
for (let x = 0; x < cols; x++) {
  for (let y = 0; y < rows; y++) {
    const desk = (y + rows * x)
    students.append({ x, y, seat: desk + 'L', action: 'idle' })
    students.append({ x, y, seat: desk + 'R', action: 'idle' })
  }
}

export default (state = students, action) => state
