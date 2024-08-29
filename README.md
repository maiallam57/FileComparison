# FileComparison

**FileComparison** is a .NET console application designed for performing various file operations. It allows users to create, modify, and compare text and binary files. The application supports basic file operations as well as advanced operations using streams, providing a versatile tool for managing and analyzing file data.

<hr/>

## Table of Contents

- [Features](#features)
- [Basic File Operations](#basic-file-operations)
- [Stream-Based File Operations](#stream-based-file-operations)
- [Usage](#usage)
- [Example](#example)

<hr/>

## Features

1. **Create Files**:
   - **Text Files**: Create new text files with user-defined content.
   - **Binary Files**: Create new binary files with user-defined byte arrays.

2. **Insert Content**:
   - **Text Files**: Insert text at a specific position within an existing text file.
   - **Binary Files**: Insert binary data at a specific position within an existing binary file.

3. **Delete Content**:
   - **Text Files**: Delete a range of text from an existing text file.
   - **Binary Files**: Delete a range of binary data from an existing binary file.

4. **Find Duplicates**:
   - **Text Files**: Identify duplicate lines between two text files.
   - **Binary Files**: Identify duplicate byte sequences between two binary files.

<hr/>

## Basic File Operations

Basic file operations include creating, inserting, and deleting content from files. These operations use the standard file handling methods provided by the .NET framework.

### Create Files

- **Text Files**: Create text files with specified content. The content is written to the file, creating a new file if it does not already exist.
- **Binary Files**: Create binary files with specified byte arrays. The binary data is written to the file, creating a new file if it does not already exist.

### Insert Content

- **Text Files**: Insert text at a specific position. The content is added to the file at the given position, shifting existing content as needed.
- **Binary Files**: Insert binary data at a specified position. The byte data is inserted into the file, adjusting the existing content accordingly.

### Delete Content

- **Text Files**: Delete a range of text from the file. The specified range is removed from the file, with the remaining content shifted as necessary.
- **Binary Files**: Delete a range of binary data. The specified byte range is removed, and the remaining binary content is adjusted.

<hr/>

## Stream-Based File Operations

Stream-based file operations involve reading and writing files using streams. Streams provide a more flexible and efficient way to handle large files and perform complex file manipulations.

### Create Files with Streams

- **Text Files**: Use `StreamWriter` to create and write text content. This approach is useful for handling large text files or performing incremental writes.
- **Binary Files**: Use `FileStream` to create and write binary data. This method is effective for handling large binary files or performing efficient data writes.

### Insert Content with Streams

- **Text Files**: Use a combination of `StreamReader` and `StreamWriter` to insert content at a specific position. Read the existing content, insert the new content, and write the updated content back to the file.
- **Binary Files**: Use `FileStream` to insert binary data. Read the existing data, insert the new bytes at the desired position, and write the updated data back to the file.

### Delete Content with Streams

- **Text Files**: Read the file content into a buffer, remove the specified range, and write the remaining content back to the file.
- **Binary Files**: Read the binary data, remove the specified range, and write the updated binary data to the file.

<hr/>

## Usage

Upon running the application, you will be presented with a menu to choose from various operations. Here’s a brief guide on how to use the application:

1. **Create Text Files**:
   - Enter the full path and content for each file.

2. **Create Binary Files**:
   - Enter the full path and binary content as a comma-separated list of bytes.

3. **Insert Content**:
   - Specify the file path, content, and position for insertion.

4. **Delete Content**:
   - Specify the file path, starting position, and length of the content to delete.

5. **Find Duplicate Lines**:
   - Provide paths to two text files to find duplicate lines.

6. **Find Duplicate Binary Content**:
   - Provide paths to two binary files to find duplicate byte sequences.

7. **Exit**:
   - Close the application.

<hr/>

## Example

An example of using the application:

1. **Create Files**:
   - Paths: `C:/Projects/FileComparison/test1.txt` and `C:/Projects/FileComparison/test2.txt`
   - Content: `Hello, World!` for `test1.txt` and `Hello, Universe!` for `test2.txt`

2. **Insert Content**:
   - Insert `Amazing` into `test1.txt` at position 13.

3. **Delete Content**:
   - Delete text from `test2.txt` starting at position 7 for a length of 8 characters.

4. **Find Duplicate Lines**:
   - Compare `test1.txt` and `test2.txt` for duplicate lines.



   <hr/>
