﻿using System;
using System.Collections.Generic;

namespace Storage.Net.Table
{
   /// <summary>
   /// Common interface for working with table storage
   /// </summary>
   public interface ISimpleTableStorage : IDisposable
   {
      /// <summary>
      /// Storage returns true if it supports optimistic concurrency. This mode affect the update
      /// operations on rows and will throw an exception if the version of the row you have is not
      /// up to date.
      /// </summary>
      bool HasOptimisticConcurrency { get; }

      /// <summary>
      /// Returns the list of all table names in the table storage
      /// </summary>
      /// <returns></returns>
      IEnumerable<string> ListTableNames();

      /// <summary>
      /// Deletes entire table
      /// </summary>
      /// <param name="tableName"></param>
      void Delete(string tableName);

      /// <summary>
      /// Gets rows by partition key
      /// </summary>
      IEnumerable<TableRow> Get(string tableName, string partitionKey);

      /// <summary>
      /// Gets a single row by partition key and row key as this uniquely idendifies a row
      /// </summary>
      TableRow Get(string tableName, string partitionKey, string rowKey);

      /// <summary>
      /// Inserts rows in the table
      /// </summary>
      void Insert(string tableName, IEnumerable<TableRow> rows);

      /// <summary>
      /// Inserts a single row
      /// </summary>
      void Insert(string tableName, TableRow row);

      /// <summary>
      /// Updates multiple rows. Note that all the rows must belong to the same partition.
      /// </summary>
      void Update(string tableName, IEnumerable<TableRow> rows);

      /// <summary>
      /// Updates single row
      /// </summary>
      void Update(string tableName, TableRow row);

      /// <summary>
      /// Merges multiple rows. Note that all rows must belong to the same partition
      /// </summary>
      void Merge(string tableName, IEnumerable<TableRow> rows);

      /// <summary>
      /// Merges a single row
      /// </summary>
      void Merge(string tableName, TableRow row);

      /// <summary>
      /// Deletes multiple rows
      /// </summary>
      void Delete(string tableName, IEnumerable<TableRowId> rowIds);

      /// <summary>
      /// Deletes a single row
      /// </summary>
      void Delete(string tableName, TableRowId rowId);
   }
}
