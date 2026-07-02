# Class Management System (C# Console Application)

## Overview

The Class Management System is a C# console-based application designed to manage student records using core data structures and object-oriented programming principles.

It demonstrates practical implementation of:

- Linked Lists for student storage and sorting
- Queues for lab management (FIFO)
- Stacks for assignment management (LIFO)

The system supports full student lifecycle management, including academic tracking through labs and assignments, with automatic performance calculations.

---

## Features

### Student Management
- Add new students
- Remove students
- Display all students in sorted order (First Name → Last Name)
- Prevent duplicate student entries

### Lab Management (Queue - FIFO)
- Add lab records
- Remove specific lab entries
- Update lab scores
- Display all labs for a student
- Calculate lab performance percentage

### Assignment Management (Stack - LIFO)
- Add assignments
- Remove assignments
- Update assignments
- Display assignments
- Calculate assignment performance percentage

### Performance Tracking
- Automatic calculation of:
  - Lab percentage
  - Assignment percentage
- Student performance summary display

---

## Technologies Used

- C#
- .NET Console Application
- Object-Oriented Programming (OOP)
- Data Structures:
  - Linked List
  - Queue
  - Stack

---

## Core Components

### Student
Represents a student and stores:
- First Name
- Last Name
- Labs (Queue)
- Assignments (Stack)

Includes methods for:
- Calculating lab percentage
- Calculating assignment percentage
- Displaying student summary

---

### Lab
Represents a lab record:
- Lab number
- Score obtained
- Maximum score

Stored using a Queue (FIFO structure).

---

### Assignment
Represents an assignment record:
- Assignment number
- Score obtained
- Maximum score

Stored using a Stack (LIFO structure).

---

### StudentLinkedList
Manages student records using a sorted linked list.

Supports:
- Adding students (sorted by first name, then last name)
- Removing students
- Searching students
- Displaying all students

---

### StudentNode
Represents a node in the linked list:
- Stores student data
- Points to next node

---

## How It Works

1. The program starts with a menu-driven interface
2. Users choose actions such as:
   - Add / Remove / Display Students
   - Manage Labs
   - Manage Assignments
3. Data is stored in memory using structured data structures
4. Performance metrics are calculated dynamically per student

---

## Input Validation

The system includes strict validation rules:

- Names must contain only letters
- Numeric inputs are safely validated using `TryParse`
- Lab score cannot exceed maximum score (10)
- Assignment score cannot exceed maximum score
- Duplicate lab and assignment entries are prevented

---

## Execution Instructions

### Prerequisites

- .NET SDK (version 6 or later recommended)
- Visual Studio, VS Code, or any C# IDE

---

### Run the Project

#### 1. Clone Repository
```bash
git clone https://github.com/your-username/ClassManagementSystem.git

```bash
cd ClassManagementSystem

```bash
dotnet build

```bash
dotnet run
