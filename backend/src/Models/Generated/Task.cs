/*
 * my todo-list API
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ToDoListAPI.Converters;

namespace ToDoListAPI.Models.Generated
{
    /// summary
    /// Represents a task with all necessary details including ID, title, description, due date, status, and associated list ID.
    /// /summary
    [DataContract]
    public partial class Task : IEquatable<Task>
    {
        /// <summary>
        /// A unique identifier for the task.
        /// </summary>
        /// <value>A unique identifier for the task.</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// The title of the task.
        /// </summary>
        /// <value>The title of the task.</value>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        /// A detailed description of the task.
        /// </summary>
        /// <value>A detailed description of the task.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The due date of the task in YYYY-MM-DD format.
        /// </summary>
        /// <value>The due date of the task in YYYY-MM-DD format.</value>
        [DataMember(Name = "due_date", EmitDefaultValue = false)]
        public DateTime DueDate { get; set; }


        /// <summary>
        /// The current status of the task.
        /// </summary>
        /// <value>The current status of the task.</value>
        [TypeConverter(typeof(CustomEnumConverter<StatusEnum>))]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum StatusEnum
        {

            /// <summary>
            /// Enum PendingEnum for pending
            /// </summary>
            [EnumMember(Value = "pending")]
            PendingEnum = 1,

            /// <summary>
            /// Enum InProgressEnum for in_progress
            /// </summary>
            [EnumMember(Value = "in_progress")]
            InProgressEnum = 2,

            /// <summary>
            /// Enum CompletedEnum for completed
            /// </summary>
            [EnumMember(Value = "completed")]
            CompletedEnum = 3
        }

        /// <summary>
        /// The current status of the task.
        /// </summary>
        /// <value>The current status of the task.</value>
        [DataMember(Name = "status", EmitDefaultValue = true)]
        public StatusEnum Status { get; set; }

        /// <summary>
        /// The identifier of the list to which this task belongs.
        /// </summary>
        /// <value>The identifier of the list to which this task belongs.</value>
        [DataMember(Name = "list_id", EmitDefaultValue = false)]
        public string ListId { get; set; }
        public string UserId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Task {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DueDate: ").Append(DueDate).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  ListId: ").Append(ListId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Task)obj);
        }

        /// <summary>
        /// Returns true if Task instances are equal
        /// </summary>
        /// <param name="other">Instance of Task to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Task other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) &&
                (
                    Title == other.Title ||
                    Title != null &&
                    Title.Equals(other.Title)
                ) &&
                (
                    Description == other.Description ||
                    Description != null &&
                    Description.Equals(other.Description)
                ) &&
                (
                    DueDate == other.DueDate ||
                    DueDate != null &&
                    DueDate.Equals(other.DueDate)
                ) &&
                (
                    Status == other.Status ||

                    Status.Equals(other.Status)
                ) &&
                (
                    ListId == other.ListId ||
                    ListId != null &&
                    ListId.Equals(other.ListId)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (Title != null)
                    hashCode = hashCode * 59 + Title.GetHashCode();
                if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                if (DueDate != null)
                    hashCode = hashCode * 59 + DueDate.GetHashCode();

                hashCode = hashCode * 59 + Status.GetHashCode();
                if (ListId != null)
                    hashCode = hashCode * 59 + ListId.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(Task left, Task right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Task left, Task right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
