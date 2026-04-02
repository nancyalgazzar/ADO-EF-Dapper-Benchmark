# Benchmark: ADO.NET vs Entity Framework vs Dapper

This project is a **benchmarking comparison** between different data access technologies in C#:

- ADO.NET  
- Entity Framework (EF)  
- Dapper  

The goal is to measure and compare their performance for common CRUD operations.

---

## 🎯 Purpose

- Evaluate performance differences between ADO.NET, EF, and Dapper  
- Understand how each technology behaves under different query scenarios  
- Identify the most efficient approach for specific use cases  

---

## 📊 Benchmark Scenarios

The project includes 5 benchmark cases:

1. **Select All (100 rows)**  
2. **Select Single Record**  
3. **Update Operation**  
4. **Select All (1000 rows)**  
5. **Select with Joined Tables**

Each scenario is implemented using:
- ADO.NET  
- Entity Framework  
- Dapper  

---

## 🛠 Technologies Used

- C#  
- .NET  
- Entity Framework  
- Dapper  
- ADO.NET  
- BenchmarkDotNet

---

## 📂 Project Structure

The project is organized into separate classes for each benchmark scenario:

- Classes for **Select All (100 rows)**  
- Classes for **Select Single Record**  
- Classes for **Update Operations**  
- Classes for **Select All (1000 rows)**  
- Classes for **Joined Tables Queries**  

Each class contains implementations using the three data access methods.

---

## 🚀 How to Run

1. Clone the repository  
2. Open the project in Visual Studio or VS Code  
3. Build the solution  
4. Run the benchmark project  
5. View the generated performance results  

---

## 📌 Notes

- This project is intended for **educational and performance comparison purposes**  
- Results may vary depending on environment, database size, and hardware  

---

## 📖 What You’ll Learn

- Performance characteristics of ADO.NET, EF, and Dapper  
- When to use each technology  
- Trade-offs between simplicity, performance, and abstraction  
- How to write and interpret benchmarks in .NET  

